<template>
  <nav
    id="nav"
    class="navbar navbar-expand-lg navbar-light bg-warning mb-3 px-3"
  >
    <div class="container-fluid">
      <a class="navbar-brand"
        ><router-link to="/movies">MovieBox</router-link></a
      >
      <button
        class="navbar-toggler"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#navbarMenu"
        aria-controls="navbarMenu"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarMenu">
        <div class="navbar-nav">
          <div class="nav-link">
            <router-link class="nav-link-item" to="/movies">Home</router-link>
          </div>
          <div class="nav-link">
            <router-link class="nav-link-item" to="/user">{{
              accessToken ? "My Profile" : "Login"
            }}</router-link>
          </div>
          <div class="nav-link nav-link-logout" v-if="accessToken">
            <a class="nav-link-item" @click="logOut">Log Out</a>
          </div>
        </div>
      </div>
    </div>
  </nav>
  <div class="container container-fluid">
    <router-view />
  </div>
</template>

<script>
import { defineComponent } from "vue";
import { mapGetters, useStore } from "vuex";

export default defineComponent({
  computed: {
    ...mapGetters({
      accessToken: "accessToken",
    }),
  },
  setup() {
    const store = useStore();

    return {
      store,
    };
  },
  methods: {
    logOut() {
      this.store.commit("setAccessToken", null);
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
