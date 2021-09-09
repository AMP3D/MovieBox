import { createStore } from "vuex";
import { Movie, UserLogin } from "../interfaces/interfaces";
import axios from "axios";
import jwtDecode, { JwtPayload } from "jwt-decode";

export type Jwt = {
  accessToken: string | null;
  accessTokenExpiration: number | null;
};

export type State = {
  currentMovie: Movie | null;
  jwt: Jwt | null;
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
      const login = await axios.post("api/users/login", payload);

      const accessToken = login?.data;
      const decodedJwt = jwtDecode<JwtPayload>(accessToken);
      const accessTokenExpiration = decodedJwt?.exp;

      const jwt: Jwt = {
        accessToken: accessToken,
        accessTokenExpiration: accessTokenExpiration || null,
      };

      commit("setJwt", jwt);
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
    setCurrentMovie(state, payload: Movie) {
      state.currentMovie = payload;

      setStateLocalStorage(state);
    },
    setJwt(state, payload: Jwt) {
      state.jwt = payload;

      setStateLocalStorage(state);
    },
    setMovies(state, payload: Movie[]) {
      state.movies = payload;

      setStateLocalStorage(state);
    },
  },
  getters: {
    currentMovie: (state) => state.currentMovie,
    movies: (state) => state.movies,
    tokenValid: (state) => {
      if (state.jwt?.accessToken && state.jwt?.accessTokenExpiration) {
        const expirationTimestamp = state.jwt?.accessTokenExpiration;
        const nowTimestamp = Math.floor(new Date().getTime() / 1000);

        return nowTimestamp < expirationTimestamp;
      }

      return false;
    },
  },
  modules: {},
});
