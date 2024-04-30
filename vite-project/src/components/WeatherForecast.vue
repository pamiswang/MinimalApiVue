<script setup lang="ts">
import { ref } from "vue";
var weatherForecastDataLsit = ref("");

async function getWeatherForecast() {
  try {
    let response = await fetch("https://localhost:8888/weatherforecast");
    let responseData = await response.json();
    console.log(responseData);
    weatherForecastDataLsit.value = responseData;
  } catch (error) {
    console.error(error);
  }
}
</script>

<template lang="">
  <button type="button" v-on:click="getWeatherForecast">
    Get Weather Forecast
  </button>

  <div v-for="weatherForecastData in weatherForecastDataLsit">
    {{ weatherForecastData.date }}
    {{ weatherForecastData.summary }}
  </div>
</template>