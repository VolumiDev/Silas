<?php
require_once('../includes/Apply.class.php');

if ($_SERVER['REQUEST_METHOD'] == 'GET') {
    

    
    $applies = Apply::getAppliesToAdmin();

    

    if ($applies) {
        //RETORNAMOS EL JSON CON LOS APLIQUES DE LA EMPRES
        header('Content-Type: application/json');
        http_response_code(200); // Status 200: OK
        echo json_encode([
            'status' => 200,
            'message' => 'Applies list',
            'applies' => $applies

        ]);
    } else {
        // Credenciales incorrectas
        header('Content-Type: application/json');
        http_response_code(401); // Status 401: Unauthorized
        echo json_encode([
            'status' => 401,
            'message' => 'Applies not found',
            'applies' => []
        ]);

    }
}

?>
