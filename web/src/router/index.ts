import { createRouter, createWebHashHistory, RouteRecordRaw } from "vue-router";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    redirect: "/movies",
  },
  {
    path: "/movies",
    name: "Movies",
    component: () =>
      import(/* webpackChunkName: "movies" */ "../views/Movies.vue"),
  },
  {
    path: "/movie-details",
    name: "MovieDetails",
    component: () =>
      import(
        /* webpackChunkName: "movie-details" */ "../views/MovieDetails.vue"
      ),
  },
  {
    path: "/user",
    name: "User",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "user" */ "../views/User.vue"),
  },
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

export default router;
