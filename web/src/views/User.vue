<template>
  <div v-if="tokenValid">
    <h3>My Profile</h3>
    <p>Page not implemented. This is a placeholder user page.</p>
  </div>
  <div v-else class="center text-center">
    <user-login @onLogin="onLogin" />
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { mapGetters, useStore } from "vuex";

import { UserLogin as UserLoginModel } from "@/interfaces/interfaces";

import UserLogin from "@/components/UserLogin.vue";

export default defineComponent({
  name: "user",
  components: {
    UserLogin,
  },
  computed: {
    ...mapGetters({
      lastRoute: "lastRoute",
      tokenValid: "tokenValid",
    }),
  },
  data() {
    return {
      lastRoutePath: null,
    };
  },
  setup() {
    const store = useStore();

    return {
      store,
    };
  },
  mounted() {
    // Set initial last-routed path so when lastRoute gets updated in the store, it doesn't take the current path
    this.lastRoutePath = this.lastRoute;
  },
  methods: {
    async onLogin(userLogin: UserLoginModel) {
      await this.store.dispatch("getAccessToken", userLogin);

      this.$router.push(this.lastRoutePath || "/movies");
    },
  },
});
</script>

<style lang="scss" scoped>
h3 {
  text-align: center;
}
</style>
