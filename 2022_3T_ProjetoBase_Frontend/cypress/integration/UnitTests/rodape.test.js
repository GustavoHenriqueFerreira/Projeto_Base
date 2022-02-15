//Método de teste - describe('descricao', função a ser executada)

describe('Componente - Rodapé', ()=> {
    
    // Pré condição
    // Abrir o navegador
    beforeEach(()=>{
        cy.visit('http://localhost:3000');
    })

    // Descrição
    it('Deve existir uma tag footer no corpo do documento', () => {
        // Pré condição

        // Procedimento
        cy.get('footer').should('exist');

        //Resultado
    })

    it('Deve conter o texto Escola Senai de Informatica', () => {
        cy.get('.rodapePrincipal section div p').should('have.text', 'Escola SENAI de Informática - 2021')
    })

    it('Deve verificar se footer está visivel e se possível uma classe chamada rodapePrincipal', () => {
        cy.get('footer').should('be.visible').and('have.class', 'rodapePrincipal')
    })
})