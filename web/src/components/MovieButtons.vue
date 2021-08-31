<template>
  <div>
    <button
      class="btn btn-primary mb-2"
      @click="showPlayBtn = true"
      v-if="!showPlayBtn"
    >
      Buy Now {{ purchasePrice }}
    </button>
  </div>
  <div>
    <button
      class="btn btn-secondary mb-2"
      @click="showPlayBtn = true"
      v-if="!showPlayBtn"
    >
      Rent Now {{ rentalPrice }}
    </button>
  </div>
  <div v-if="showPlayBtn">
    <button class="btn btn-danger mb-2" @click="showPlayBtn = false">
      Return
    </button>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "movie-buttons",
  props: {
    purchasePrice: Number,
    rentalPrice: Number,
  },
  emits: ["onPlayerChange"],
  watch: {
    showPlayBtn() {
      this.$emit("onPlayerChange", this.showPlayBtn);
    },
  },
  data() {
    return {
      showPlayBtn: false,
    };
  },
});
</script>

<style lang="scss" scoped>
button {
  min-width: 200px;
}
</style>
