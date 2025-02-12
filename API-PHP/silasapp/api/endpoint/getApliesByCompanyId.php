<?php
require_once('../includes/Companies.class.php');

if ($_SERVER['REQUEST_METHOD'] == 'GET') {
    
    $id_company = $_GET['id_company'];

    
    $applies = Company::getApliesByCompanyId($id_company);

    if ($applies) {
        //RETORNAMOS EL JSON CON LOS APLIQUES DE LA EMPRES
        header('Content-Type: application/json');
        http_response_code(200); // Status 200: OK
        echo json_encode([
            'status' => 200,
            'message' => 'Aplies list',
            'applies' => $applies

        ]);
    } else {
        // Credenciales incorrectas
        header('Content-Type: application/json');
        http_response_code(401); // Status 401: Unauthorized
        echo json_encode([
            'status' => 401,
            'message' => 'Aplies not found',
            'applies' => []
        ]);

    }
}

?>
