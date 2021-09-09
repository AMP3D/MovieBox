<template>
  <div>
    <button
      class="btn btn-primary mb-2"
      @click="this.$emit('onPurchase')"
      v-if="!isPlaying"
    >
      Buy Now {{ purchasePrice }}
    </button>
  </div>
  <div>
    <button
      class="btn btn-secondary mb-2"
      @click="this.$emit('onRent')"
      v-if="!isPlaying"
    >
      Rent Now {{ rentalPrice }}
    </button>
  </div>
  <div v-if="isPlaying">
    <button class="btn btn-danger mb-2" @click="this.$emit('onReturn')">
      Return
    </button>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "movie-buttons",
  props: {
    isPlaying: Boolean,
    purchasePrice: Number,
    rentalPrice: Number,
  },
  emits: ["onPurchase", "onRent", "onReturn"],
});
</script>

<style lang="scss" scoped>
button {
  min-width: 200px;
}
</style>
