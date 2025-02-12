<?php
require_once('../includes/Companies.class.php');

header('Content-Type: application/json');

if ($_SERVER['REQUEST_METHOD'] == 'GET') 
{
    if (isset($_GET['id'])) 
    {
        $idUser = $_GET['id'];
        $company = Company::getCompanyById($idUser);
        try 
        {
            if ($company) 
            {
                http_response_code(200); // OK
                echo json_encode($company);
            } 
        } 
        catch (Exception $e) 
        {
            http_response_code(500); 
            echo json_encode(['error' => 'Error al obtener los detalles de la empresa']);
        }
    } 
    else 
    {
        http_response_code(400); 
        echo json_encode(['error' => 'No id_user ']);
    }
} 
?>
