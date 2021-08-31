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
          @click="gotoMovie(movie)"
        />
      </swiper-slide>
    </swiper>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { mapGetters, useStore } from "vuex";

// Import Swiper Vue.js components
import { Swiper, SwiperSlide } from "swiper/vue";
import SwiperCore, { Pagination, Navigation } from "swiper";

// install Swiper modules
SwiperCore.use([Pagination, Navigation]);

import "swiper/swiper-bundle.css";
import { Movie } from "@/interfaces/interfaces";

export default defineComponent({
  name: "MoviesSwiper",
  components: {
    Swiper,
    SwiperSlide,
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
  methods: {
    gotoMovie(movie: Movie) {
      this.store.commit("setCurrentMovie", movie);

      this.$router.push("/movie-details");
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
