<?php
require_once('../includes/Company.class.php');

header('Content-Type: application/json');

if ($_SERVER['REQUEST_METHOD'] === 'POST') 
{
    $body = json_decode(file_get_contents('php://input'), true);

    if 
    (
        isset($body['id_user']) &&
        isset($body['address']) &&
        isset($body['telephone']) &&
        isset($body['contact']) &&
        isset($body['mobile'])
    ) 
    {
        $idUser = $body['id_user'];
        $address = $body['address'];
        $telephone = $body['telephone'];
        $contact = $body['contact'];
        $mobile = $body['mobile'];
        $status = isset($body['status']) ? $body['status'] : 1;

        try 
        {
            Company::createCompanyDetails($idUser, $address, $telephone, $contact, $mobile, $status);
            http_response_code(201); // OK
            echo json_encode(['message' => 'Detalles de la empresa creados correctamente']);
        } 
        catch (Exception $e) 
        {
            http_response_code(500); 
            echo json_encode(['error' => 'Error al crear los detalles de la empresa']);
        }
    } 
    else 
    {
        http_response_code(400); 
        echo json_encode(['error' => 'Faltan campos']);
    }
}
?>
