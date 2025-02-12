<?php
require_once('../includes/Database.class.php');

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $body = json_decode(file_get_contents('php://input'), true);
    if(isset($body['id'], $body['title'], $body['description'], $body['id_course'], $body['date'], $body['location'], $body['id_company'])) {
        $id = $body['id'];
        $title = $body['title'];
        $description = $body['description'];
        $id_course = $body['id_course'];
        $date = $body['date'];
        $location = $body['location'];
        $id_company = $body['id_company'];
        
        $database = new Database();
        $conn = $database->getConnection();
        $sql = "UPDATE offers SET title = :title, description = :description, id_course = :id_course, date = :date, location = :location, id_company = :id_company WHERE id = :id";
        $stmt = $conn->prepare($sql);
        $stmt->bindParam(':title', $title);
        $stmt->bindParam(':description', $description);
        $stmt->bindParam(':id_course', $id_course, PDO::PARAM_INT);
        $stmt->bindParam(':date', $date);
        $stmt->bindParam(':location', $location);
        $stmt->bindParam(':id_company', $id_company, PDO::PARAM_INT);
        $stmt->bindParam(':id', $id, PDO::PARAM_INT);
        
        if($stmt->execute()){
            header('200 OK');
            echo json_encode(['message' => 'Oferta actualizada correctamente']);
        } else {
            header('500');
            echo json_encode(['error' => 'Error al actualizar oferta (500 del server)']);
        }
    } 
} 
?>
