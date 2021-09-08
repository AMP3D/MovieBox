import { createStore } from "vuex";
import { Movie, UserLogin } from "../interfaces/interfaces";
import axios from "axios";

export type State = {
  accessToken: string | null;
  currentMovie: Movie | null;
  movies: Movie[];
};

const getStateLocalStorage = () => {
  const json = localStorage.getItem("state");
  return json ? JSON.parse(json) : null;
};

const setStateLocalStorage = (state: State) => {
  if (state) {
    const json = JSON.stringify(state);
    localStorage.setItem("state", json);
  }
};

const localStorageState = getStateLocalStorage();

const state: State = localStorageState
  ? localStorageState
  : {
      currentMovie: null,
      movies: [],
    };

export default createStore({
  state: state,
  actions: {
    async getAccessToken({ commit }, payload: UserLogin) {
      const accessToken = await axios.post("api/users/login", payload);

      commit("setAccessToken", accessToken.data);
    },
    async getMovies({ commit }) {
      const movies = await axios.get("api/movies");

      commit("setMovies", movies.data);
    },
    setMovies({ commit }, payload: Movie[]) {
      commit("setMovies", payload);
    },
  },
  mutations: {
    setAccessToken(state, payload: string) {
      state.accessToken = payload;

      setStateLocalStorage(state);
    },
    setCurrentMovie(state, payload: Movie) {
      state.currentMovie = payload;

      setStateLocalStorage(state);
    },
    setMovies(state, payload: Movie[]) {
      state.movies = payload;

      setStateLocalStorage(state);
    },
  },
  getters: {
    accessToken: (state) => state.accessToken,
    currentMovie: (state) => state.currentMovie,
    movies: (state) => state.movies,
  },
  modules: {},
});
