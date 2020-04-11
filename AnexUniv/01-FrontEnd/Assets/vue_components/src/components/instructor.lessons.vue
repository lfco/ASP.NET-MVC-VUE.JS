<template>
<div>
  <loader v-if="loading" height="200"></loader>
  <ul v-if="!loading" class="list-group">
    <!-- Listado de las lecciones creadas -->
    <li class="list-group-item">
        <div class="input-group">
            <input type="text" class="form-control" value="Lección #@h" readonly>
            <span class="input-group-btn">
                <button class="btn btn-danger" type="button" title="Eliminar">
                    <i class="fa fa-trash"></i>
                </button>
                <button data-toggle="modal" data-target="#lesson-edit" class="btn btn-default" type="button" title="Editar">
                    <i class="fa fa-edit"></i>
                </button>
            </span>
        </div>
    </li>

    <!-- Nuevas lecciones -->
    <li class="list-group-item">
        <div v-if="newEntry.Error.length > 0" class="alert alert-danger">{{ newEntry.Error }}</div>
        <div class="input-group">
            <input v-model="newEntry.Name" type="text" class="form-control" placeholder="Nueva lección">
            <span class="input-group-btn">
                <button @click="insert" class="btn btn-default" type="button" title="Registrar">
                    <i class="fa fa-plus"></i>
                </button>
            </span>
        </div>
    </li>
  </ul>
</div>
</template>

<script>
import loader from './global.loader.vue'
export default {
  name: 'instructorlesson',
  components: {
    loader
  },
  props: {
    id: {
      type: Number,
      requide: true
    }
  },
  data() {
    return {
      loading: false,
      newEntry: {
        Name: '',
        Error: ''
      }
    }
  },
  mounted() {
    //this.get();
  },
  computed: {
    
  },
  methods: {
    all() {
      // let self = this;
      // $.post(self.url, {
      //   userId: self.userId
      // }, function(r) {
      //   self.Total = r.Total;
      //   self.TotalPerMonth = r.TotalPerMonth;
      //   self.Students = r.Students;
      //   self.Reputation = r.Reputation;
      // }, 'json')
    },
    get() {

    },
    update() {

    },
    insert() {
      let self = this;
      self.loading = true;

      $.post('/instructor/insertlesson', {
        courseId: self.id,
        Name: self.newEntry.Name
      }, function(r) {
        self.loading = false;

        if(!r.Response) {
          // Si hay error mostramos mensaje
          self.newEntry.Error = r.Message;
        } else {
          // En caso de exito limpiamos todo
          self.newEntry.Name = '';
          self.newEntry.Error = '';
        }
      }, 'json')
    },
    delete() {

    }
  }
}
</script>