describe('Integração - OCR', () => {
    
    beforeEach(() =>{
        cy.visit('http://localhost:3000');
    })

    it('Deve logar e inserir a imagem OCR retornando o valor correto da mesma', ()=>{

        cy.get('.cabecalhoPrincipal-nav-login').should('exist')
        cy.get('.cabecalhoPrincipal-nav-login').click()
        
        cy.get('.input__login').first().type('gustavo@email.com')
        cy.get('.input__login').last().type('123456789')
        //Mais do que um: cy.get('.input__login').[0]first().type('gustavo@email.com')

        cy.get('#btn__login').click()

        
        cy.wait(500)
        
        cy.get('.input__login').first().type('slaaaaa')
        cy.get('input[type=file]').first().selectFile('src/assets/tests/equipamento.png')
        cy.get('input[type=file]').last().selectFile('src/assets/tests/equipamento.png')
        cy.get('#codigoPatrimonio').should('have.value', '1202530')
        cy.get('.btn__cadastro').click()
        cy.wait(5000)
        cy.get('.excluir').last().click()

        //cy.get('#codigoPatrimonio').should('have.value', '1202530')
    })
})