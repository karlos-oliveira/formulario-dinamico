function MontaFormularioDinamico(container, campos) {
    container.innerHTML = '';
    campos = campos.sort(function(a, b){return a.ordem - b.ordem});

    campos.forEach(campo => {
        let divLinha = document.createElement('div');
        let divDescricao = document.createElement('div');
        let divValor = document.createElement('div');
        let labelDescricao = document.createElement('label');

        divLinha.id = campo.idAtributo;
        divLinha.style = 'display: block;padding: 10px;'

        divDescricao.style = 'padding: 10px;display: inline;';
        divValor.style = 'padding: 10px;display: inline;';

        if(campo.multiplaEscolha)
        {
            labelDescricao.textContent = campo.label;

            if(campo.tipo == 'select')
            {
                let selectValor = document.createElement('select');

                selectValor.id = campo.nomeCampo;
                selectValor.name = campo.nomeCampo;
                selectValor.title = campo.descricao;

                campo.opcoes.split("|").forEach(op => {
                    let opcao = document.createElement('option');

                    opcao.value = op;
                    opcao.text = op;

                    selectValor.appendChild(opcao);
                });
                
                divValor.appendChild(selectValor);
            }
            else
            {
                campo.opcoes.split("|").forEach((op, i) => {
                    let inputValor = document.createElement('input');
                    let idOpcao = campo.nomeCampo + i;
                    let labelOp = document.createElement('label');
                    
                    labelOp.attributes.setNamedItem(document.createAttribute('for'));
                    labelOp.attributes.getNamedItem('for').value = idOpcao;  
                    labelOp.textContent = op;
    
                    inputValor.id = idOpcao;
                    inputValor.name = campo.nomeCampo;
                    inputValor.type = campo.tipo;
                    inputValor.title = campo.descricao + ' opção: ' + op;
                    
                    divValor.appendChild(inputValor);
                    divValor.appendChild(labelOp);
                });
            }
            
        }
        else
        {
            let inputValor = document.createElement('input');

            labelDescricao.attributes.setNamedItem(document.createAttribute('for'));
            labelDescricao.attributes.getNamedItem('for').value = campo.nomeCampo;
            labelDescricao.textContent = campo.label;

            inputValor.id = campo.nomeCampo;
            inputValor.name = campo.nomeCampo;
            inputValor.type = campo.tipo;
            inputValor.required = campo.obrigatorio;
            inputValor.maxLength = campo.tamanhoMaximo;
            inputValor.title = campo.descricao;
            
            divValor.appendChild(inputValor);
        }

        divDescricao.appendChild(labelDescricao);
        divLinha.appendChild(divDescricao);
        divLinha.appendChild(divValor);

        container.appendChild(divLinha);
    });
}


