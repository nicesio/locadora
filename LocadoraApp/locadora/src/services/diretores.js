import { http } from './config'

export default {
    listar: () => {
        return http.get('diretor/')
    },

    salvar: (diretor) => {
        return http.post('diretor/', diretor)
    },

    atualizar: (diretor) => {
        return http.put('diretor/' + diretor.id, diretor)
    },

    apagar: (diretor) => {
        return http.delete('diretor/' + diretor.id)
    }
}