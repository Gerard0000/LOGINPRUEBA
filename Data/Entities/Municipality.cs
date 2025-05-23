﻿using System.ComponentModel.DataAnnotations;

namespace LOGINPRUEBA.web.Data.Entities;

public class Municipality
{
    public int Id { get; set; }

    [MaxLength(100)]
    [Display(Name = "Municipio")]
    [Required(ErrorMessage = "El {0} es requerido.")]
    public string? Name { get; set; }

    [MaxLength(4)]
    [MinLength(4, ErrorMessage = "El {0} no puede tener menos de {1} carácteres")]
    [Display(Name = "Código de Municipio")]
    [Required(ErrorMessage = "El {0} es requerido.")]
    public string? CodMunHn { get; set; }

    [MaxLength(255)]
    [Display(Name = "Observación")]
    public string? Observation { get; set; }

    [Display(Name = "Fecha de Creación")]
    [DataType(DataType.DateTime)]
    public DateTime CreationDate { get; set; }

    [Display(Name = "Creador")]
    public string? Creator { get; set; }

    [Display(Name = "Fecha de Modificación")]
    [DataType(DataType.DateTime)]
    public DateTime ModificationDate { get; set; }

    [Display(Name = "Modificador")]
    public string? Modifier { get; set; }

    [Display(Name = "Fecha de Creación")]
    public DateTime DateLocalCreation => CreationDate.ToLocalTime();

    [Display(Name = "Fecha de Modificación")]
    public DateTime DateLocalModification => ModificationDate.ToLocalTime();

    [Display(Name = "Departamento")]
    public Department? Department { get; set; }

    public ICollection<User>? Users { get; set; }

    //CONTARME JUZGADOS
    [Display(Name = "Número de Usuarios")]
    public int UsersNumber => Users == null ? 0 : Users.Count;
}