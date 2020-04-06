<template>
<div>
  <div class="form-group">
      <label>Ícono</label>
      <div class="input-group">
          <input v-model="selectedIcon" type="text" class="form-control" name="Icon">
          <span class="input-group-addon"><icon :name="selectedIcon"></icon></span>
      </div>
  </div>
  <div class="form-group">
      <label>Nombre</label>
      <input type="text" class="form-control" name="Name">
  </div>
</div>  
</template>

<script>
import icon from './global.icon.vue'
export default {
  components: {
    icon
    },
    data(){
      return {
        selectedIcon: 'code'
      }
      },
  name: 'category',
  props: {
    id: {
      type: Number,
      default: 0
    }
  },
  mounted() {
    this.$parent.$on('categorySelectedID', id => {
      this.id = id;
    })
  }
}
</script>