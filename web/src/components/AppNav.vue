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
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { mapGetters, useStore } from "vuex";

export default defineComponent({
  name: "app-nav",
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

<style lang="scss" scoped>
h3 {
  text-align: center;
}

.user-login-fields > div {
  margin-bottom: 10px;
  min-width: 300px;
  text-align: left;
}
</style>
