

namespace VelocityCoders.FitnessPractice.Models
{
    /// <summary>
    /// Represents the Instructor subheader navigation whe navigating within the Instructor pages.
    /// The text of the enum should also match the physical name of the aspx file.
    /// </summary>
    public enum InstructorNavigation
    {
        /// <summary>
        /// Default to one value
        /// </summary>
        None,

        /// <summary>
        /// Page contains a list of all of the instructors
        /// </summary>
        InstructorList,

        /// <summary>
        /// Page contains basic Instructor information
        /// </summary>
        InstructorForm,

        /// <summary>
        /// Page contains Instructor contact information
        /// </summary>
        ContactInfo,

        /// <summary>
        /// Page contains the association between Instructor and Fitness class
        /// </summary>
        FitnessClass,

        /// <summary>
        /// Page contains the association between Instructor and Location
        /// </summary>
        Locations
    }

}
