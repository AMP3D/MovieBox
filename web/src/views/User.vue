<template>
  <div v-if="accessToken">
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
    async onLogin(userLogin: UserLoginModel) {
      await this.store.dispatch("getAccessToken", userLogin);

      this.$router.push("/movies");
    },
  },
});
</script>

<style lang="scss" scoped>
h3 {
  text-align: center;
}
</style>
