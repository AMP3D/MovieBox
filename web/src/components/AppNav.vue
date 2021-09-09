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
        data-target="#navbarMenu"
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
              tokenValid ? "My Profile" : "Sign In"
            }}</router-link>
          </div>
          <div class="nav-link nav-link-signout" v-if="tokenValid">
            <a class="nav-link-item" @click="signOut">Sign Out</a>
          </div>
        </div>
      </div>
    </div>
  </nav>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { mapGetters, useStore } from "vuex";

export default defineComponent({
  name: "app-nav",
  computed: {
    ...mapGetters({
      tokenValid: "tokenValid",
    }),
  },
  setup() {
    const store = useStore();

    return {
      store,
    };
  },
  methods: {
    signOut() {
      this.store.commit("setJwt", null);
    },
  },
});
</script>

<style lang="scss" scoped>
h3 {
  text-align: center;
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
