<?php
require_once('../includes/Student.class.php');

if ($_SERVER['REQUEST_METHOD'] == 'GET') {
    
    if (!isset($_GET['id_student'])) {
        header('Content-Type: application/json');
        http_response_code(400); // Bad Request
        echo json_encode([
            'status' => 400,
            'message' => 'El parámetro id_student es requerido.'
        ]);
        exit;
    }
    
    $id_student = intval($_GET['id_student']);
    
    // Llamamos al método estático de la clase Student que se encarga de
    // ejecutar la consulta y emitir la respuesta en JSON.
    Student::getStudentById($id_student);
    
} else {
    header('Content-Type: application/json');
    http_response_code(405); // Method Not Allowed
    echo json_encode([
        'status' => 405,
        'message' => 'Método no permitido.'
    ]);
}
?>