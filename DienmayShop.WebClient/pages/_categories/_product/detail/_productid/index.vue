<template>
    <Fragment>
        <section class="bg-primary padding-y-sm">
            <div class="container">
                <ol class="breadcrumb ondark mb-0">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item"><a href="#">Library</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Data</li>
                </ol>
            </div>
        </section>
        <section class="padding-y">
            <div class="container">

                <div class="row">
                    <ProductGallery />
                    <DetailAreaSpectification />
                </div>
            </div>
        </section>
        <DetailArea />
        <Comment />
    </Fragment>
</template>
<script>
import { Fragment } from 'vue-fragment'
export default {
    components: {
        Fragment
    }
}
</script>