<template>
  <div v-if="accessToken">
    <h3>My Profile</h3>
    <p>Page not implemented. This is a placeholder user page.</p>
  </div>
  <div v-else class="center text-center">
    <user-login />
  </div>
</template>

<script>
import { defineComponent } from "vue";
import { mapGetters } from "vuex";
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
});
</script>

<style lang="scss" scoped>
h3 {
  text-align: center;
}
</style>
