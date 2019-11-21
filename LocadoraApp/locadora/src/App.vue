<template id ="filmes">
  <div id="app">

    <nav>
      <div class="nav-wrapper blue darken-1">
        <a href="#" class="brand-logo center">Locadora</a>
      </div>
    </nav>

    <div class="container">

    <ul>
      <li v-for="(erro, index) of errors" :key="index">
        compo <b> {{erro.field}} </b> - {{erro.defaultMessage}}
      </li>
    </ul>

      <form @submit.prevent="salvar">

          <label>Nome do Filme</label>
          <input type="text" placeholder="Nome" v-model="filme.nomeFilme">
          <label>Data de Lançamento</label>
          <input type="text" placeholder="DTLANCAMENTO" v-model="filme.dataLancamento">
          <label>Diretor</label>
          <input type="number" placeholder="DiretorId" v-model="filme.diretorId">
          <button class="waves-effect waves-light btn-small">Salvar<i class="material-icons left">save</i></button>

      </form>

      <table>

        <thead>

          <tr>
            <th>NOME</th>
            <th>DTLANCAMENTO</th>
            <th>DiretorId</th>
            <th>OPÇÕES</th>
          </tr>

        </thead>

        <tbody>

          <tr v-for = "filme of filmes" :key="filme.id">

            <td>{{ filme.nomeFilme }}</td>
            <td>{{ filme.dataLancamento }}</td>
            <td>{{ filme.diretorId }}</td>
            <td>
              <button @click="editar(filme)" class="waves-effect btn-small blue darken-1"><i class="material-icons">create</i></button>
              <button @click="remover(filme)" class="waves-effect btn-small red darken-1"><i class="material-icons">delete_sweep</i></button>
            </td>

          </tr>

        </tbody>
      
      </table>

    </div>

  </div>
</template>




<div>
<p>
  <router-link to ="/filmes">Filmes</router-link>
  <router-link to ="/diretores">Diretores</router-link>
</p>
</div>

<router-view></router-view>

<script src="https://unpkg.com/vue-router/dist/vue-router.js"></script>
<script>

  const Filmes = { template: 'dilmes' }
  const Diretores = { template: 'diretores' }

  const routes = [
    { path: '/filmes', component: Filmes },
    { path: '/diretores', component: Diretores }
  ]

  // const router = new VueRouter({
  //   routes 
  // })

  // const app = new Vue({
  //   router
  // }).$mount('#app')
  
  import Filme from './services/filmes'

  export default {
  
    data(){
      return {
        filme: {
          id: '',
          nomeFilme: '',
          dataLancamento: '',
          diretorId: ''
        },
        filmes: [],
        errors: []
      }
    },

    mounted() {
      this.listar()
    },

    methods: {
      listar(){
      Filme.listar().then( resposta => {
        /* eslint-disable no-console */
        console.log(resposta.data)
        this.filmes = resposta.data
        })
      },
      salvar() {
        if(!this.filme.id){
          Filme.salvar(this.filme).then(resposta => {
           this.filme = {}
           alert('Salvo com sucesso')
           /* eslint-disable no-console */
           console.log(resposta)
           this.listar()
           this.errors = []
          }).catch(e => {
            this.errors = e.response.data.errors
          })
        }else{
          Filme.atualizar(this.filme).then(resposta => {
            this.filme = {}
            alert('Atualizado com sucesso')
            /* eslint-disable no-console */
            console.log(resposta)
            this.listar()
            this.errors = []
          }).catch(e => {
            this.errors = e.response.data.errors
          })
        }
        
      },

      editar(filme) {
        this.filme = filme
      },

      remover(filme) {
        /* eslint-disable no-console */
        if(confirm('Deseja excluir o filme?')){
          filme.apagar(filme).then(resposta => {
          console.log(resposta)
          this.listar()
          this.errors = []
        }).catch(e=>{
          this.errors = e.response.data.errors
        })
        }
      },
    },
  } 
</script>

<style>

</style>
