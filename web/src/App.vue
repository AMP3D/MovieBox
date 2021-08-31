<template>
  <app-nav />
  <div class="container container-fluid">
    <router-view />
  </div>
</template>

<script>
import { defineComponent } from "vue";
import AppNav from "@/components/AppNav.vue";

// eslint-disable-next-line @typescript-eslint/no-unused-vars
import Collapse from "bootstrap/dist/js/bootstrap";

export default defineComponent({
  components: {
    AppNav,
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

#nav {
  a {
    color: #000000;
    cursor: pointer;
    font-weight: bold;
    text-decoration: none;

    &.nav-link-item:hover {
      text-decoration: underline;
    }
  }
}
</style>
