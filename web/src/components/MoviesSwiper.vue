<template>
  <div class="row">
    <h3>Now Trending</h3>
    <swiper
      :slides-per-view="4"
      :space-between="20"
      :loop="true"
      :navigation="true"
      :pagination="{
        clickable: true,
        type: 'bullets',
      }"
    >
      <swiper-slide
        v-for="movie of movies"
        :key="movie.id"
        :title="movie.title"
      >
        <img
          class="movie-img"
          :src="movie.imageUrl"
          :alt="movie.title"
          @click="movieSelected(movie)"
        />
      </swiper-slide>
    </swiper>
  </div>
</template>

<script lang="ts">
import { defineComponent, PropType } from "vue";

// Import Swiper Vue.js components
import { Swiper, SwiperSlide } from "swiper/vue";
import SwiperCore, { Pagination, Navigation } from "swiper";

// install Swiper modules
SwiperCore.use([Pagination, Navigation]);
import "swiper/swiper-bundle.css";

import { Movie } from "@/interfaces/interfaces";

export default defineComponent({
  name: "movies-swiper",
  components: {
    Swiper,
    SwiperSlide,
  },
  props: {
    movies: Object as PropType<Movie[]>,
  },
  emits: ["onMovieSelected"],
  methods: {
    movieSelected(movie: Movie) {
      this.$emit("onMovieSelected", movie);
    },
  },
});
</script>

<style lang="scss" scoped>
.movie-img {
  cursor: pointer;
  height: 400px;
  width: 300px;
}
</style>
