<?php
require_once('../includes/Offer.class.php');

header('Content-Type: application/json');

if ($_SERVER['REQUEST_METHOD'] == 'POST') 
{
    // Retrieve JSON input
    $data = json_decode(file_get_contents("php://input"), true);

    // Check if all required fields are provided
    if (!empty($data['title']) && !empty($data['description']) && !empty($data['id_course']) 
        && !empty($data['date']) && !empty($data['location']) && !empty($data['id_company'])) 
    {
        $response = Offer::createOffer(
            $data['title'], 
            $data['description'], 
            $data['id_course'], 
            $data['date'], 
            $data['location'], 
            $data['id_company']
        );

        if ($response['success']) 
        {
            http_response_code(201); // Created
        } 
        else 
        {
            http_response_code(400); // Bad Request
        }

        echo json_encode($response);
    } 
    else 
    {
        http_response_code(400);
        echo json_encode(['success' => false, 'message' => 'Missing required fields']);
    }
} 
else 
{
    http_response_code(405); // Method Not Allowed
    echo json_encode(['success' => false, 'message' => 'Invalid request method']);
}
?>
