import Vue from 'vue'
import icon from './components/global.icon.vue'
import loader from './components/global.loader.vue'
import rating from './components/global.rating.vue'
import price from './components/global.price.vue'

window.Vue = Vue
window.Components = {
    icon, loader, rating, price
}