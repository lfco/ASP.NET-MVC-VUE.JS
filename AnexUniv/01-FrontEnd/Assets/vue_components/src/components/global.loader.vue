<template>
  <div class="block-loading" :style="{ height: height + 'px' }"></div>
</template>

<script>
export default {
  name: 'loader',
  props: ['height']
}
</script>