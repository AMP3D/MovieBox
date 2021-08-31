<template>
  <form>
    <div class="row g-3">
      <div class="user-login-fields col-sm-4 mx-auto">
        <div>
          <label for="user-login-userName">User name</label>
          <input
            type="text"
            class="form-control"
            id="user-login-userName"
            :value="userName"
            @change="userName = $event"
          />
        </div>
        <div>
          <label for="user-login-password">Password</label>
          <input
            type="password"
            class="form-control"
            id="user-login-password"
            :value="password"
            @change="password = $event"
          />
        </div>
        <div class="text-left">
          <button
            type="submit"
            class="btn btn-primary"
            id="user-login-submit"
            @click="submit"
          >
            Login
          </button>
        </div>
      </div>
    </div>
  </form>
</template>

<script lang="ts">
import { UserLogin } from "@/interfaces/interfaces";
import { defineComponent } from "vue";
import { useStore } from "vuex";

export default defineComponent({
  name: "user-login",
  setup() {
    const store = useStore();

    return {
      store,
    };
  },
  data() {
    return {
      password: "@bc123#$456",
      userName: "admin",
    };
  },
  methods: {
    async login() {
      await this.store.dispatch("getAccessToken");
    },
    submit() {
      const userLogin = {
        password: this.password,
        userName: this.userName,
      } as UserLogin;

      this.store.dispatch("getAccessToken", userLogin);
      this.$router.push("/movies");
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
