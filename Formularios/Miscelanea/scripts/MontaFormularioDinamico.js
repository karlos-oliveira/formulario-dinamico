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
                let divContainer = document.createElement('div');
                
                divContainer.classList.add('input-field');
                divContainer.classList.add('col');
                divContainer.classList.add('s12');

                selectValor.id = campo.nomeCampo;
                selectValor.name = campo.nomeCampo;
                selectValor.title = campo.descricao;

                campo.opcoes.split("|").forEach(op => {
                    let opcao = document.createElement('option');

                    opcao.value = op;
                    opcao.text = op;

                    selectValor.appendChild(opcao);
                });
                
                divContainer.appendChild(selectValor);
                divValor.appendChild(divContainer);
            }
            else
            {
                campo.opcoes.split("|").forEach((op, i) => {
                    let inputValor = document.createElement('input');
                    let idOpcao = campo.nomeCampo + i;
                    let labelOp = document.createElement('span');
                    let labelContainer = document.createElement('label');

                    labelContainer.style="padding-left: 10px;padding-right: 10px;";
                    labelOp.textContent = op;
    
                    inputValor.id = idOpcao;
                    inputValor.name = campo.nomeCampo;
                    inputValor.type = campo.tipo;
                    inputValor.title = campo.descricao + ' opção: ' + op;
                    
                    labelContainer.appendChild(inputValor);
                    labelContainer.appendChild(labelOp);
                    divValor.appendChild(labelContainer);
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

function MontaPreview(container, campos) {
    let ulExpansivel = document.createElement('ul');
    
    container.innerHTML = '';
    campos = campos.sort(function(a, b){return a.ordem - b.ordem});

    campos.forEach(campo => {
        let divLinha = document.createElement('div');
        let divDescricao = document.createElement('div');
        let divValor = document.createElement('div');
        let labelDescricao = document.createElement('label');
        let isMultiEscolha = isMultiplaEscolha(campo.tipo);
        
        divLinha.id = campo.idAtributo;
        divLinha.style = `display: block;padding: 10px;${ isMultiEscolha ? "height: 150px;": ""}`;

        divDescricao.style = 'padding: 10px;';
        divValor.style = 'padding: 10px;display: inline;';

        labelDescricao.textContent = `Preview do campo "${campo.label}"`;

        if(isMultiEscolha)
        {
            // labelDescricao.textContent = campo.label;

            if(campo.tipo == 'select' && campo.opcoes)
            {
                let selectValor = document.createElement('select');
                let divContainer = document.createElement('div');
                
                divContainer.classList.add('input-field');
                divContainer.classList.add('col');
                divContainer.classList.add('s12');

                selectValor.id = campo.nomeCampo;
                selectValor.name = campo.nomeCampo;
                selectValor.title = campo.descricao;

                // campo.opcoes.split("|").forEach(op => {
                campo.opcoes.forEach(op => {
                    let opcao = document.createElement('option');

                    opcao.value = op;
                    opcao.text = op;

                    selectValor.appendChild(opcao);
                });
                
                divContainer.appendChild(selectValor);
                divValor.appendChild(divContainer);
            }
            else if (campo.opcoes)
            {
                // campo.opcoes.split("|").forEach((op, i) => {
                campo.opcoes.forEach((op, i) => {
                    let inputValor = document.createElement('input');
                    let idOpcao = campo.nomeCampo + i;
                    let labelOp = document.createElement('span');
                    let labelContainer = document.createElement('label');

                    labelContainer.style="padding-left: 10px;padding-right: 10px;";
                    labelOp.textContent = op;
    
                    inputValor.id = idOpcao;
                    inputValor.name = campo.nomeCampo;
                    inputValor.type = campo.tipo;
                    inputValor.title = campo.descricao + ' opção: ' + op;
                    
                    labelContainer.appendChild(inputValor);
                    labelContainer.appendChild(labelOp);
                    divValor.appendChild(labelContainer);
                });
            }
            
        }
        else
        {
            let inputValor = document.createElement('input');

            labelDescricao.attributes.setNamedItem(document.createAttribute('for'));
            labelDescricao.attributes.getNamedItem('for').value = campo.nomeCampo;

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


        let pObrig = document.createElement("p");
        let labelObrig = document.createElement("label");
        let inputObrig = document.createElement("input");
        let spanObrig = document.createElement("span");

        inputObrig.type = "checkbox";
        inputObrig.checked = campo.obrigatorio;
        spanObrig.innerText = "Obrigatório";

        labelObrig.appendChild(inputObrig);
        labelObrig.appendChild(spanObrig);
        pObrig.appendChild(labelObrig);
       
        let liExpansivel = document.createElement("li");
        let divHeader = document.createElement("div");
        let divBody =  document.createElement("div");
        
        ulExpansivel.classList.add("collapsible");
        ulExpansivel.classList.add("popout");
        divHeader.classList.add("collapsible-header");
        divBody.classList.add("collapsible-body");

        divHeader.append(campo.label);

        divBody.appendChild(pObrig);
        
        if(isMultiEscolha)
        {
            let divOpcoes = document.createElement("div");
            let labelOpcoes = document.createElement("div");
            
            labelOpcoes.innerText = `Informe as opções para o campo "${campo.label}"`;

            divOpcoes.classList.add(campo.idAtributo);
            divOpcoes.classList.add("divOpcoes");
            divOpcoes.classList.add("chips");
            divOpcoes.classList.add("chips-placeholder");
            divBody.appendChild(labelOpcoes);
            divBody.appendChild(divOpcoes);
        }

        divBody.appendChild(divLinha);

        liExpansivel.appendChild(divHeader);
        liExpansivel.appendChild(divBody);

        ulExpansivel.appendChild(liExpansivel);
        container.appendChild(ulExpansivel);
    });

    let aSalvar = document.createElement("a");

    aSalvar.classList.add("waves-effect");
    aSalvar.classList.add("waves-light");
    aSalvar.classList.add("btn-small");
    aSalvar.innerText = "Salvar";

    aSalvar.addEventListener('click', () => associarAtributoModelo(),false)
    container.appendChild(aSalvar);
}

function isMultiplaEscolha(tipo){
    switch (tipo.toLowerCase()) {
        case "select":
            return true;
        case "checkbox":
            return true;
        case "radio":
            return true
        default:
            return false
    }
}