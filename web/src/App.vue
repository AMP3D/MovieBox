<template>
  <app-nav />
  <div class="container container-fluid">
    <router-view />
  </div>
</template>

<script>
import { defineComponent } from "vue";
import { useStore } from "vuex";

import AppNav from "@/components/AppNav.vue";

// eslint-disable-next-line @typescript-eslint/no-unused-vars
import Collapse from "bootstrap/dist/js/bootstrap";

export default defineComponent({
  components: {
    AppNav,
  },
  watch: {
    $route(to, from) {
      this.store.commit("setLastRoute", from?.path);
    },
  },
  created() {
    window.removeEventListener("beforeunload", this.onBeforeUnload);
    window.addEventListener("beforeunload", this.onBeforeUnload);
  },
  setup() {
    const store = useStore();

    return {
      store,
    };
  },
  methods: {
    onBeforeUnload() {
      // Before a page refresh takes effect and clears state, persist it to local storage
      this.store.dispatch("saveState");
    },
  },
});
</script>

<style lang="scss">
#app {
  color: #ffffff;
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}
</style>
