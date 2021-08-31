<template>
  <movies-swiper />
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { useStore } from "vuex";
import MoviesSwiper from "@/components/MoviesSwiper.vue";

export default defineComponent({
  name: "movies-view",
  components: {
    MoviesSwiper,
  },
  async created() {
    const store = useStore();

    await store.dispatch("getMovies");
  },
});
</script>

<style lang="scss" scoped>
.movie-img {
  height: 400px;
  width: 300px;
}
</style>
