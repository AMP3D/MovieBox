<template>
  <movies-swiper :movies="movies" @onMovieSelected="onMovieSelected" />
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { mapGetters, useStore } from "vuex";

import { Movie } from "@/interfaces/interfaces";

import MoviesSwiper from "@/components/MoviesSwiper.vue";

export default defineComponent({
  name: "movies",
  components: {
    MoviesSwiper,
  },
  computed: {
    ...mapGetters({
      movies: "movies",
    }),
  },
  setup() {
    const store = useStore();

    return {
      store,
    };
  },
  async created() {
    await this.store.dispatch("getMovies");
  },
  methods: {
    onMovieSelected(movie: Movie) {
      this.store.commit("setCurrentMovie", movie);

      this.$router.push("/movie-details");
    },
  },
});
</script>

<style lang="scss" scoped>
.movie-img {
  height: 400px;
  width: 300px;
}
</style>
