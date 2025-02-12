<?php
require_once('../includes/Course.class.php');

header('Content-Type: application/json');

if ($_SERVER['REQUEST_METHOD'] == 'GET') 
{
    try 
    {
        $courses = Course::listAllCourses();
        
        if ($courses) 
        {
            http_response_code(200); // OK
            echo json_encode($courses);
        } 
        else 
        {
            http_response_code(404); // Not Found
            echo json_encode(['error' => 'No courses found']);
        }
    } 
    catch (Exception $e) 
    {
        http_response_code(500); // Internal Server Error
        echo json_encode(['error' => 'Error retrieving course data']);
    }
}
else 
{
    http_response_code(405); // Method Not Allowed
    echo json_encode(['error' => 'Invalid request method']);
}
?>
