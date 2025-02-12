<?php
require_once('../includes/Offers_Student.php');

header('Content-Type: application/json');

if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    if (isset($_GET['id_user'])) {
        $id_user = $_GET['id_user'];

        try {
            $offers = Offer::listOffersByCompanyId($id_user);
            http_response_code(200); // OK
            echo json_encode($offers);
        } catch (Exception $e) {
            http_response_code(500);
            echo json_encode(['error' => 'Error al cargar ofertas']);
        }

    } else {
        http_response_code(400);
        echo json_encode(['error' => 'id_user no existe']);
    }
}
