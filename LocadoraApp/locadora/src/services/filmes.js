import { http } from './config'

export default {
    listar: () => {
        return http.get('filme/')
    },

    salvar: (filme) => {
        return http.post('filme/', filme)
    },

    atualizar: (filme) => {
        return http.put('filme/' + filme.id, filme)
    },

    apagar: (filme) => {
        return http.delete('filme/' + filme.id)
    }
}