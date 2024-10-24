import java.io.*;
import java.util.ArrayList;
import java.util.List;

public class ControlTareas {

    List<Tarea> tareas;

    private static final String ARCHIVO = "tareas.txt" ;

    public ControlTareas(){
        this.tareas = new ArrayList<>();
        optenerTareasArchivoTxt();
    }

    public void agregarTarea(String resumen)  {
        Tarea tarea = new Tarea();
        tarea.setTarea(resumen);
        tarea.setCompletada("Pendiente");
        tareas.add(tarea);

        try (BufferedWriter writer = new BufferedWriter(new FileWriter(ARCHIVO, true))){

            writer.write(tarea.getTarea() + ";" + tarea.completada());
            writer.newLine();
        } catch (IOException e) {

            System.out.println("Error al guardar tareas: " + e.getMessage());
        }

        System.out.println("Tarea agregada correctamente.");
    }

    public void listarTareas(){

        if(tareas.isEmpty()){
            System.out.println("Lista de tareas vacia");
        }else {

            for (int i = 0; i < tareas.size(); i++) {
                Tarea tarea = tareas.get(i);
                System.out.println(i + ": " + tarea.getTarea() + " " + tarea.completada());
            }
        }
    }

    private void optenerTareasArchivoTxt() {

        File archivo = new File(ARCHIVO);
        if (archivo.exists()){

            try( BufferedReader leer = new BufferedReader(new FileReader(archivo))){
                String leerLinea;
                while( (leerLinea = leer.readLine()) != null){
                    String[] partes = leerLinea.split(";");
                    if (partes.length == 2){
                        String resumen = partes[0];
                         String completado = partes[1];
                        Tarea tarea = new Tarea();
                       tarea.setTarea(resumen);
                        tarea.setCompletada(completado);
                        tareas.add(tarea);
                    }

                }
                System.out.println("Listado de tareas correctamente");
            } catch (IOException e){
                System.out.println("Error en Cargar Tareas " + e.getMessage());
            }
        }else {
            System.out.println("Archivo tareas no encontrado");
        }
    }
}
