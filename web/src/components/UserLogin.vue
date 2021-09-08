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
import { defineComponent } from "vue";

import { UserLogin } from "@/interfaces/interfaces";

export default defineComponent({
  name: "user-login",
  emits: ["onLogin"],
  data() {
    return {
      password: "@bc123#$456",
      userName: "admin",
    };
  },
  methods: {
    submit() {
      const userLogin = {
        password: this.password,
        userName: this.userName,
      } as UserLogin;

      this.$emit("onLogin", userLogin);
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
