<template>
  <!-- <img class="movie-player" :src="videoSrc" />
  <i class="play-btn"><font-awesome-icon icon="play-circle" size="6x" /></i>
  <div class="text-right">Placeholder for real video</div> -->

  <LiteYouTubeEmbed
    id="dQw4w9WgXcQ"
    title="Rick Astley - Never Gonna Give You Up (Official Music Video)"
  />
</template>

<script lang="ts">
import { defineComponent } from "vue";
//import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

import LiteYouTubeEmbed from "vue-lite-youtube-embed";
import "vue-lite-youtube-embed/dist/style.css";

export default defineComponent({
  name: "movie-player",
  props: {
    videoSrc: String,
  },
  components: {
    //FontAwesomeIcon,
    LiteYouTubeEmbed,
  },
});
</script>

<style lang="scss" scoped>
.movie-player {
  height: 300px;
  width: 100%;
}

.play-btn {
  color: white;
  cursor: pointer;
  margin-left: -60%;
  vertical-align: middle;
}
</style>
