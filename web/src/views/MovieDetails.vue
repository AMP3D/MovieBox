<template>
  <h1>{{ movie.title }}</h1>
  <div class="row">
    <div class="col-auto mb-1">
      <img :src="movie.imageUrl" :alt="movie.title" />
    </div>
    <div class="col-auto">
      <div>
        <button class="btn btn-primary mb-2">
          Buy Now {{ movie.purchasePrice }}
        </button>
      </div>
      <div>
        <button class="btn btn-secondary mb-2">
          Rent Now {{ movie.rentalPrice }}
        </button>
      </div>
      <section class="details">
        <div>Title: {{ movie.title }}</div>
        <div>Year Released: {{ movie.yearReleased }}</div>
        <div>Rating: {{ movie.rating }}</div>
      </section>
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

export default defineComponent({
  name: "MovieDetails",
  computed: {
    ...mapGetters({
      movie: "currentMovie",
    }),
  },
});
</script>

<style lang="scss" scoped>
button {
  min-width: 200px;
}

img {
  height: 300px;
  width: 200px;
}
</style>
