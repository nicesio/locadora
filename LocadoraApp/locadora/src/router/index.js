import Vue from 'vue'
import Router from 'vue-router'
import Diretores from './../components/Diretores'

Vue.use(Router)

export default new Router({
    routes: [{
        path: '/diretores',
        name: 'Diretores',
        component: Diretores
    }],
    linkActiveClass: 'active'
})