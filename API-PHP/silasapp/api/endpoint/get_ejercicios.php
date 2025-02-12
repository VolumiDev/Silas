<?php

require('../includes/Ejercicios.php');

if($_SERVER['REQUEST_METHOD'] == 'GET'){

    $ejercicios = Ejercicio::getEjericios();

    if($ejercicios){
        print json_encode(
            array(
                'estado' => '1',
                'mensaje' => 'Se obtuvieron los ejercicios correctamente',
                'data' => $ejercicios,
            ));
    }else{
        print json_encode(
            array(
                'estado' => '1',
                'mensaje' => 'No se obtuvieron ejercicios',
                'data' => [],
            ));
    }
}

?>