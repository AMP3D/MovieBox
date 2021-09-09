<template>
  <h1>{{ movie.title }}</h1>
  <div class="row">
    <div class="col-auto mb-1">
      <img class="movie-image" :src="movie.imageUrl" :alt="movie.title" />
    </div>
    <div class="col-auto">
      <movie-buttons
        :isPlaying="showPlayer"
        :rentalPrice="movie.rentalPrice"
        :purchasePrice="movie.purchasePrice"
        @onPurchase="handlePlayer(true)"
        @onRent="handlePlayer(true)"
        @onReturn="handlePlayer(false)"
      />
      <section class="details">
        <div>Title: {{ movie.title }}</div>
        <div>Year Released: {{ movie.yearReleased }}</div>
        <div>Rating: {{ movie.rating }}</div>
      </section>
    </div>
    <div class="col-xl-6" v-if="showPlayer && tokenValid">
      <movie-player :videoSrc="movie.imageUrl" />
    </div>
  </div>
  <div class="mt-5">
    <div>Summary:</div>
    <p>
      {{ movie.summary }}
    </p>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { mapGetters, useStore } from "vuex";
import MovieButtons from "@/components/MovieButtons.vue";
import MoviePlayer from "@/components/MoviePlayer.vue";

export default defineComponent({
  name: "movie-details",
  components: {
    MovieButtons,
    MoviePlayer,
  },
  computed: {
    ...mapGetters({
      movie: "currentMovie",
      tokenValid: "tokenValid",
      userMovies: "userMovies",
    }),
  },
  watch: {
    tokenValid(isValid) {
      // Hide player if user is not signed in
      if (!isValid) {
        this.showPlayer = false;
      }
    },
  },
  data() {
    return {
      showPlayer: false,
    };
  },
  setup() {
    const store = useStore();

    return {
      store,
    };
  },
  mounted() {
    if (this.tokenValid && this.userMovies[this.movie.id]) {
      this.showPlayer = true;
    }
  },
  methods: {
    handlePlayer(showPlayer: boolean) {
      this.showPlayer = showPlayer;

      if (showPlayer) {
        this.store.commit("addUserMovie", this.movie);
      } else {
        this.store.commit("removeUserMovie", this.movie);
      }

      // Send to user page for login if no valid token
      if (!this.tokenValid) {
        this.$router.push("/user");
      }
    },
  },
});
</script>

<style lang="scss" scoped>
.movie-image {
  height: 300px;
  width: 200px;
}
</style>
