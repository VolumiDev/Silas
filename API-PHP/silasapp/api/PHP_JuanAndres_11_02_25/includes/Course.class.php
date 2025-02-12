<?php
require_once('Database.class.php');

class Course
{
    /**
     * Recoger la informacion de todos los cursos.
     */
    public static function listAllCourses()
    {
        $database = new Database();
        $conn = $database->getConnection();

        $stmt = $conn->prepare('SELECT * FROM course'); 
        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }
}
?>
