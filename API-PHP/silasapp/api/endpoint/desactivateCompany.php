<?php

require_once('../includes/Company.class.php');

header('Content-Type: application/json');

if ($_SERVER['REQUEST_METHOD'] === 'POST') 
{
    $body = json_decode(file_get_contents('php://input'), true);

    if (isset($body['id_user'])) 
    {
        $idUser = $body['id_user'];

        try 
        {
            Company::deactivateCompany($idUser);
            http_response_code(200); // OK
            echo json_encode(['message' => 'Empresa desactivada correctamente']);
        } 
        catch (Exception $e) 
        {
            http_response_code(500); 
            echo json_encode(['error' => 'Error al desactivar la empresa']);
        }
    }
     else 
     {
        http_response_code(400); 
        echo json_encode(['error' => 'No id_user']);
    }
} 
?>
