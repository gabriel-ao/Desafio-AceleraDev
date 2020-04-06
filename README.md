# Desafio-AceleraDev

#### Desafio AceleraDev
Codenation - React 

</br>
Resumo
Este repositório é referente ao código utilizado para resolver o desafio Acelera Dev. A linguagem utilizada é p .net 

</br>
Proposta do desafio
Escrever programa, em qualquer linguagem de programação, que faça uma requisição HTTP para a url 'https://api.codenation.dev/v1/challenge/dev-ps/generate-data?token=SEU_TOKEN'. O resultado da requisição vai ser um JSON conforme o exemplo:

{
	"numero_casas": 10,
	"token":"token_do_usuario",
	"cifrado": "texto criptografado",
	"decifrado": "aqui vai o texto decifrado",
	"resumo_criptografico": "aqui vai o resumo"
}

O primeiro passo é você salvar o conteúdo do JSON em um arquivo com o nome answer.json, que irá usar no restante do desafio. Você deve usar o número de casas para decifrar o texto e atualizar o arquivo JSON, no campo decifrado. O próximo passo é gerar um resumo criptográfico do texto decifrado usando o algoritmo sha1 e atualizar novamente o arquivo JSON. OBS: você pode usar qualquer biblioteca de criptografia da sua linguagem de programação favorita para gerar o resumo sha1 do texto decifrado. Seu programa deve submeter o arquivo atualizado para correção via POST para a API: 'https://api.codenation.dev/v1/challenge/dev-ps/submit-solution?token=SEU_TOKEN'

</br>
OBS: a API espera um arquivo sendo enviado como multipart/form-data, como se fosse enviado por um formulário HTML, com um campo do tipo file com o nome answer. Considere isso ao enviar o arquivo.

</br>
O resultado da submissão vai ser sua nota ou o erro correspondente. Você pode submeter quantas vezes achar necessário, mas a API não vai permitir mais de uma submissão por minuto.

</br>
Funcionalidades da aplicação
O console inicia já com o url salvo com o Token gerado pela Codenation.dev. do candidato em uma string chamada GetUrl.
Após entrado o dado, a aplicação envia uma requisição para a api da codenation e espera receber de volta um json contendo, 
entre os dados, uma mensagem criptografada e o número de casas puladas segundo a criptografia de Júlio Cesar. 
Estas duas informações são mostradas na tela. Também é gerado um array de chars da string da mensagem 
criptografada. O resultado obtido é utilizado novamente para descriptograr a mensagem e criptografar em sha1 e atualiza o 
arquivo .json e com isso unindo todas as informações necessárias e envia com o nome "answer" para a api. A api retorna 
a nota do usuário para finalizar.
