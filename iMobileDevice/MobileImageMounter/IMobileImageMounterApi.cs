// <copyright file="IMobileImageMounterApi.cs" company="Quamotion">
// Copyright (c) 2016 Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.MobileImageMounter
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public partial interface IMobileImageMounterApi
    {
        
        /// <summary>
        /// Gets or sets the <see cref="ILibiMobileDeviceApi"/> which owns this <see cref="MobileImageMounter"/>.
        /// </summary>
        ILibiMobileDevice Parent
        {
            get;
        }
        
        /// <summary>
        /// Connects to the mobile_image_mounter service on the specified device.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="service">
        /// The service descriptor returned by lockdownd_start_service.
        /// </param>
        /// <param name="client">
        /// Pointer that will be set to a newly allocated
        /// mobile_image_mounter_client_t upon successful return.
        /// </param>
        /// <returns>
        /// MOBILE_IMAGE_MOUNTER_E_SUCCESS on success,
        /// MOBILE_IMAGE_MOUNTER_E_INVALID_ARG if device is NULL,
        /// or MOBILE_IMAGE_MOUNTER_E_CONN_FAILED if the connection to the
        /// device could not be established.
        /// </returns>
        MobileImageMounterError mobile_image_mounter_new(iDeviceHandle device, LockdownServiceDescriptorHandle service, out MobileImageMounterClientHandle client);
        
        /// <summary>
        /// Starts a new mobile_image_mounter service on the specified device and connects to it.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="client">
        /// Pointer that will point to a newly allocated
        /// mobile_image_mounter_t upon successful return. Must be freed using
        /// mobile_image_mounter_free() after use.
        /// </param>
        /// <param name="label">
        /// The label to use for communication. Usually the program name.
        /// Pass NULL to disable sending the label in requests to lockdownd.
        /// </param>
        /// <returns>
        /// MOBILE_IMAGE_MOUNTER_E_SUCCESS on success, or an MOBILE_IMAGE_MOUNTER_E_* error
        /// code otherwise.
        /// </returns>
        MobileImageMounterError mobile_image_mounter_start_service(iDeviceHandle device, out MobileImageMounterClientHandle client, string label);
        
        /// <summary>
        /// Disconnects a mobile_image_mounter client from the device and frees up the
        /// mobile_image_mounter client data.
        /// </summary>
        /// <param name="client">
        /// The mobile_image_mounter client to disconnect and free.
        /// </param>
        /// <returns>
        /// MOBILE_IMAGE_MOUNTER_E_SUCCESS on success,
        /// or MOBILE_IMAGE_MOUNTER_E_INVALID_ARG if client is NULL.
        /// </returns>
        MobileImageMounterError mobile_image_mounter_free(System.IntPtr client);
        
        /// <summary>
        /// Tells if the image of ImageType is already mounted.
        /// </summary>
        /// <param name="client">
        /// The client use
        /// </param>
        /// <param name="image_type">
        /// The type of the image to look up
        /// </param>
        /// <param name="result">
        /// Pointer to a plist that will receive the result of the
        /// operation.
        /// </param>
        /// <returns>
        /// MOBILE_IMAGE_MOUNTER_E_SUCCESS on success, or an error code on error
        /// </returns>
        /// <remarks>
        /// This function may return MOBILE_IMAGE_MOUNTER_E_SUCCESS even if the
        /// operation has failed. Check the resulting plist for further information.
        /// </remarks>
        MobileImageMounterError mobile_image_mounter_lookup_image(MobileImageMounterClientHandle client, string imageType, out PlistHandle result);
        
        /// <summary>
        /// Uploads an image with an optional signature to the device.
        /// </summary>
        /// <param name="client">
        /// The connected mobile_image_mounter client.
        /// </param>
        /// <param name="image_type">
        /// Type of image that is being uploaded.
        /// </param>
        /// <param name="image_size">
        /// Total size of the image.
        /// </param>
        /// <param name="signature">
        /// Buffer with a signature of the image being uploaded. If
        /// NULL, no signature will be used.
        /// </param>
        /// <param name="signature_size">
        /// Total size of the image signature buffer. If 0, no
        /// signature will be used.
        /// </param>
        /// <param name="upload_cb">
        /// Callback function that gets the data chunks for uploading
        /// the image.
        /// </param>
        /// <param name="userdata">
        /// User defined data for the upload callback function.
        /// </param>
        /// <returns>
        /// MOBILE_IMAGE_MOUNTER_E_SUCCESS on succes, or a
        /// MOBILE_IMAGE_MOUNTER_E_* error code otherwise.
        /// </returns>
        MobileImageMounterError mobile_image_mounter_upload_image(MobileImageMounterClientHandle client, string imageType, uint imageSize, byte[] signature, ushort signatureSize, MobileImageMounterUploadCallBack uploadCallBack, System.IntPtr userdata);
        
        /// <summary>
        /// Mounts an image on the device.
        /// </summary>
        /// <param name="client">
        /// The connected mobile_image_mounter client.
        /// </param>
        /// <param name="image_path">
        /// The absolute path of the image to mount. The image must
        /// be present before calling this function.
        /// </param>
        /// <param name="signature">
        /// Pointer to a buffer holding the images' signature
        /// </param>
        /// <param name="signature_size">
        /// Length of the signature image_signature points to
        /// </param>
        /// <param name="image_type">
        /// Type of image to mount
        /// </param>
        /// <param name="result">
        /// Pointer to a plist that will receive the result of the
        /// operation.
        /// </param>
        /// <returns>
        /// MOBILE_IMAGE_MOUNTER_E_SUCCESS on success,
        /// MOBILE_IMAGE_MOUNTER_E_INVALID_ARG if on ore more parameters are
        /// invalid, or another error code otherwise.
        /// </returns>
        /// <remarks>
        /// This function may return MOBILE_IMAGE_MOUNTER_E_SUCCESS even if the
        /// operation has failed. Check the resulting plist for further information.
        /// Note that there is no unmounting function. The mount persists until the
        /// device is rebooted.
        /// </remarks>
        MobileImageMounterError mobile_image_mounter_mount_image(MobileImageMounterClientHandle client, string imagePath, byte[] signature, ushort signatureSize, string imageType, out PlistHandle result);
        
        /// <summary>
        /// Hangs up the connection to the mobile_image_mounter service.
        /// This functions has to be called before freeing up a mobile_image_mounter
        /// instance. If not, errors appear in the device's syslog.
        /// </summary>
        /// <param name="client">
        /// The client to hang up
        /// </param>
        /// <returns>
        /// MOBILE_IMAGE_MOUNTER_E_SUCCESS on success,
        /// MOBILE_IMAGE_MOUNTER_E_INVALID_ARG if client is invalid,
        /// or another error code otherwise.
        /// </returns>
        MobileImageMounterError mobile_image_mounter_hangup(MobileImageMounterClientHandle client);
    }
}
