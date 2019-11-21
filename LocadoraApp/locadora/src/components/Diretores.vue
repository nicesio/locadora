<template>
  <div id="app">

    <nav>
      <div class="nav-wrapper blue darken-1">
        <a href="#" class="brand-logo center">Locadora</a>
      </div>
    </nav>

    <div class="container">

    <ul>
      <li v-for="(erro, index) of errors" :key="index">
        campo <b> {{erro.field}} </b> - {{erro.defaultMessage}}
      </li>
    </ul>

      <form @submit.prevent="salvar">

          <label>Nome do Diretor</label>
          <input type="text" placeholder="Nome" v-model="diretor.nomeDiretor">
          <button class="waves-effect waves-light btn-small">Salvar<i class="material-icons left">save</i></button>

      </form>

      <table>

        <thead>

          <tr>
            <th>NOME</th>
            <th>OPÇÕES</th>
          </tr>

        </thead>

        <tbody>

          <tr v-for = "diretor of diretores" :key="diretor.id">

            <td>{{ diretor.nomeDiretor }}</td>
            <td>
              <button @click="editarDiretor(diretor)" class="waves-effect btn-small blue darken-1"><i class="material-icons">create</i></button>
              <button @click="removerDiretor(diretor)" class="waves-effect btn-small red darken-1"><i class="material-icons">delete_sweep</i></button>
            </td>

          </tr>

        </tbody>
      
      </table>

    </div>

  </div>
</template>

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
  
  import Diretor from './../services/diretores'
  

  export default {
  
    data(){
      return {
        diretor: {
          id: '',
          nomeDiretor: ''
        },
        diretores:[],
        errors: []
      }
    },

    mounted() {
      this.listarDiretor()
    },

    methods: {
      listarDiretor(){
      Diretor.listar().then( resposta => {
        /* eslint-disable no-console */
        console.log(resposta.data)
        this.diretores = resposta.data
        })
      },

      salvarDiretor() {
        if(!this.diretor.id){
          Diretor.salvar(this.diretor).then(resposta => {
           this.diretor = {}
           alert('Salvo com sucesso')
           /* eslint-disable no-console */
           console.log(resposta)
           this.listarDiretor()
           this.errors = []
          }).catch(e => {
            this.errors = e.response.data.errors
          })
        }else{
          Diretor.atualizar(this.diretor).then(resposta => {
            this.diretor = {}
            alert('Atualizado com sucesso')
            /* eslint-disable no-console */
            console.log(resposta)
            this.listarDiretor()
            this.errors = []
          }).catch(e => {
            this.errors = e.response.data.errors
          })
        }
        
      },

      editarDiretor(diretor) {
        this.diretor = diretor
      },
      
      removerDiretor(diretor) {
        /* eslint-disable no-console */
        if(confirm('Deseja excluir o Diretor?')){
          diretor.apagar(diretor).then(resposta => {
          console.log(resposta)
          this.listarDiretor()
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