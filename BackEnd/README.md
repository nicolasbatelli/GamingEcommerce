# Simple Gameming Ecommerce Application

Back End:

Property: title
	 Equals “=” (coincidencia exacta y case sensitive)
	 Contains “:” (coincidencia parcial y case insensitive)
Property: salePrice
	 Greater than “>” (mayor que)
	 Less than “<” (menor que)
	
Ejemplos: (los siguientes se mandarían a través de una petición GET “/deals?q=filter_string”)
	 “q=title = Batman” deberá devolver solo aquellos deals con el nombre exactamente
igual a “Batman”
	 “q=title : call of” deberá devolver aquellos deals con coincidencia parcial (sin tener en
cuenta las mayúsculas/minúsculas) como por ejemplo “Call of duty”, “Call of Juarez”,
etc.
	 “q=salePrice > 30” deberá devolver todos aquellos deals con precio mayor a $30
	
Los filtros deben poder ser combinados para lograr una búsqueda más acotada, utilizando una
coma “,” como separador. Por ejemplo:
“title : Call of , salePrice < 50 , salePrice > 10” deberá retornar todos aquellos deals cuyo title
contengan el substring “call of” (case insensitive) Y que tengan la property salePrice entre $10 y
$50.

Importante:

	 Cuando el filtro no posea ningún operador se deberá realizar por defecto una operación
contains a la property title, del string de búsqueda. Ej: si ingreso como filtro el string
“call of” (no posee operadores) debería retornar lo mismo que si se hubiera enviado el
string “title : call of”

	 Cuando el filtro sea inválido (por no usar el operador adecuado), por ejemplo
“title > 50” se deberá retornar un Array vacío desde la RestAPI.

FrontEnd:

Instalar node
Dentro de la carpeta "FrontEnd" correr npm install
Correr npm start y la applicacion comenzara a correr