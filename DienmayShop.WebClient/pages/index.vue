<template>
  <Fragment >
    <Intro />
    <Product />
    <Feature />
    <RecentlyViewed />
    <AboutUs />
  </Fragment >
</template>

<script>
import { Fragment } from 'vue-fragment'
export default {
  name: 'IndexPage',
  components: {
    Fragment
  }
}
</script>
