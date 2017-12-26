function somaValores2(a,b) {
  //Remover os pontos
  a = replaceAll(a,'.','');
  b = replaceAll(b,'.','');
  //Trocar virgulas pelo . para reconhecer como double valido
  a = a.replace(',',".");
  b = b.replace(',',".");
  //Efetuar soma  
  total = Number(a) + Number(b);
 
  return total;   
}

function somaValores4(a,b,c,d) {
  //Remover os pontos
  a = replaceAll(a,'.','');
  b = replaceAll(b,'.','');
  c = replaceAll(c,'.','');
  d = replaceAll(d,'.','');
  //Trocar virgulas pelo . para reconhecer como double valido
  a = a.replace(',',".");
  b = b.replace(',',".");
  c = c.replace(',',".");
  d = d.replace(',',".");
  //Efetuar soma  
  total = Number(a) + Number(b) + Number(c) + Number(d);
 
  return total;   
}

function formataCurrency(num) {
    num = num.toString();
    if(isNaN(num))
        num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num*100+0.500000000000000000001);
    cents = num%100;
    num = Math.floor(num/100).toString();
    
    if(cents<10)
        cents = "0" + cents;
    
    for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
        num = num.substring(0,num.length-(4*i+3))+'.'+
    
    num.substring(num.length-(4*i+3));
    return (((sign)?'':'-') + num + ',' + cents);
}

function replaceAll(string, token, newtoken) {
	while (string.indexOf(token) != -1) {
 		string = string.replace(token, newtoken);
	}
	return string;
}
    
function atualizaValoresTotal(idTotal,idRealizado,idFuturo,idDivida,idNaoDivida)
{
    var pai = document.getElementById(idTotal);
    var filho1 = document.getElementById(idRealizado);
    var filho2 = document.getElementById(idFuturo);
    var filho3 = document.getElementById(idDivida);
    var filho4 = document.getElementById(idNaoDivida);
        
    pai.value = somaValores4(filho1.value,filho2.value, filho3.value, filho4.value);	
    pai.value = formataCurrency(pai.value);
}

function atualizaValoresAno(idAno,idDivida,idNaoDivida)
{
    var pai = document.getElementById(idAno);
    var filho1 = document.getElementById(idDivida);
    var filho2 = document.getElementById(idNaoDivida);
        
    pai.value = somaValores2(filho1.value,filho2.value);	
    pai.value = formataCurrency(pai.value);
}    

function AtualizaValorTotal(idTotal,idRealizado,idFuturo,idDivida,idNaoDivida)
{
    atualizaValoresTotal(idTotal,idRealizado,idFuturo,idDivida,idNaoDivida);
    //formataValor(campo,ev);
}
function AtualizaValorAno(idAno,idDivida,idNaoDivida)
{
    atualizaValoresAno(idAno,idDivida,idNaoDivida);
    //formataValor(campo,ev);
} 