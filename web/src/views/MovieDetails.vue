<template>
  <h1>{{ movie.title }}</h1>
  <div class="row">
    <div class="col-auto mb-1">
      <img class="movie-image" :src="movie.imageUrl" :alt="movie.title" />
    </div>
    <div class="col-auto">
      <movie-buttons
        :rentalPrice="movie.rentalPrice"
        :purchasePrice="movie.purchasePrice"
        @onPlayerChange="showPlayer = $event"
      />
      <section class="details">
        <div>Title: {{ movie.title }}</div>
        <div>Year Released: {{ movie.yearReleased }}</div>
        <div>Rating: {{ movie.rating }}</div>
      </section>
    </div>
    <div class="col" v-if="showPlayer">
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
import { mapGetters } from "vuex";
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
    }),
  },
  data() {
    return {
      showPlayer: false,
    };
  },
});
</script>

<style lang="scss" scoped>
.movie-image {
  height: 300px;
  width: 200px;
}
</style>
